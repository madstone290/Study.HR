import {
    DatePicker,
    AutoComplete,
    Button,
    Checkbox,
    Col,
    Form,
    Input,
    InputNumber,
    Row,
    Select,
} from 'antd';
import { useEffect, useRef, useState } from 'react';
import { Employee, SalaryType } from '../../data/employee';
const { Option } = Select;


const formItemLayout = {
    labelCol: {
        span: 8
    },
    wrapperCol: {
        span: 16,
    },
};

export function EmployeeForm({ initialEmployee, bindState }) {
    console.log("Rendering EmployeeForm");
    const defaultRequired = true;
    const [form] = Form.useForm();
    const employeeRef = useRef(initialEmployee);

    useEffect(() => {
        const state = {
            validate: async () => {
                try {
                    await form.validateFields();
                    return true;
                } catch {
                    return false;
                }
            }
        }
        bindState(state);
    }, [])

    useEffect(() => {
        form.resetFields();
        form.setFieldsValue(initialEmployee);
        employeeRef.current = initialEmployee;
    }, [initialEmployee])


    const formValueChanged = (changedValues, values) => {
        const [key, value] = Object.entries(changedValues)[0]

        employeeRef.current[key] = value;
        if (key == "enteredDateAsDate" && value) {
            employeeRef.current.enteredDateAsString = value.format("YYYY-MM-DD");
        }
        else if (key == "phoneNumberHead" || key == "phoneNumberBody") {
            employeeRef.current.mergePhoneNumber();
        }
    };

    return (
        <Form
            {...formItemLayout}
            form={form}
            name="register"
            onValuesChange={formValueChanged}
            scrollToFirstError
        >

            <Row>
                <Col span={12}>
                    <Form.Item name="name"
                        label="이름"
                        rules={[
                            {
                                required: defaultRequired,
                                message: "이름을 입력하세요",
                            },
                        ]}
                    >
                        <Input />
                    </Form.Item>
                </Col>
                <Col span={12}>
                    <Form.Item
                        name="email"
                        label="E-mail"
                        rules={[
                            {
                                type: 'email',
                                message: 'The input is not valid E-mail!',
                            },
                            {
                                required: defaultRequired,
                                message: 'Please input your E-mail!',
                            },
                        ]}
                    >
                        <Input />
                    </Form.Item>
                </Col>
            </Row>

            <Row>
                <Col span={12}>
                    <Form.Item
                        name="salaryType"
                        label="급여 타입"
                        rules={[
                            {
                                required: defaultRequired,
                                message: "급여를 선택하세요!",
                            },
                        ]}
                    >
                        <Select placeholder="급여 타입을 선택하세요">
                            <Option value={SalaryType.Monthly}>월급</Option>
                            <Option value={SalaryType.Weekly}>주급</Option>
                            <Option value={SalaryType.Hourly}>시급</Option>
                        </Select>
                    </Form.Item>
                </Col>
                <Col span={12}>

                    <Form.Item
                        name="phoneNumberBody"
                        label="Phone Number"
                        rules={[
                            {
                                required: false,
                                message: 'Please input your phone number!',
                            },
                        ]}
                    >
                        <Input
                            addonBefore={
                                <Form.Item name="phoneNumberHead" noStyle>
                                    <Select
                                        style={{
                                            width: 70,
                                        }}
                                    >
                                        <Option value="010">010</Option>
                                        <Option value="011">011</Option>
                                    </Select>
                                </Form.Item>
                            }
                            style={{
                                width: '100%',
                            }}
                        />
                    </Form.Item>

                </Col>
            </Row>

            <Row>
                <Col span={12}>
                    <Form.Item
                        name="baseSalary"
                        label="기준 급여"
                        rules={[
                            {
                                required: false,
                                message: '기준 급여를 입력하세요!',
                            },
                        ]}
                    >
                        <InputNumber
                            addonAfter={
                                <Form.Item name="salaryCurrency" noStyle
                                    rules={[
                                        {
                                            required: false,
                                            message: "통화를 선택하세요"
                                        }
                                    ]}>
                                    <Select
                                        style={{
                                            width: 70,
                                        }}
                                    >
                                        <Option value="WON">₩</Option>
                                        <Option value="USD">$</Option>
                                        <Option value="CNY">¥</Option>
                                    </Select>
                                </Form.Item>
                            }
                            style={{
                                width: '100%',
                            }}
                        />
                    </Form.Item>

                </Col>
                <Col span={12}>
                    <Form.Item
                        name="loginId"
                        label="로그인ID"
                        tooltip="로그인에 사용되는 아이디"
                        rules={[
                            {
                                required: defaultRequired,
                                message: '아이디를 입력하세요',
                                whitespace: true,
                            },
                        ]}
                    >
                        <Input />
                    </Form.Item>
                </Col>
            </Row>

            <Row>
                <Col span={12}>
                    <Form.Item
                        name="confirm"
                        label="Confirm Password"
                        dependencies={['password']}
                        hasFeedback
                        rules={[
                            {
                                required: defaultRequired,
                                message: 'Please confirm your password!',
                            },
                            ({ getFieldValue }) => ({
                                validator(_, value) {
                                    if (!value || getFieldValue('password') === value) {
                                        return Promise.resolve();
                                    }
                                    return Promise.reject(new Error('The two passwords that you entered do not match!'));
                                },
                            }),
                        ]}
                    >
                        <Input.Password />
                    </Form.Item>
                </Col>
                <Col span={12}>
                    <Form.Item
                        name="password"
                        label="Password"
                        rules={[
                            {
                                required: defaultRequired,
                                message: 'Please input your password!',
                            },
                        ]}
                        hasFeedback
                    >
                        <Input.Password />
                    </Form.Item>
                </Col>
            </Row>

            <Row>
                <Col span={12}>
                    <Form.Item
                        name="enteredDateAsDate"
                        label="입사일"
                        rules={[
                            {
                                required: true,
                                message: "입사일을 선택하세요"
                            }
                        ]}
                    >
                        <DatePicker style={{ width: "100%" }} />
                    </Form.Item>
                </Col>
                <Col span={12}>
                    <Form.Item
                        name="desc"
                        label="설명"
                    >
                        <Input.TextArea showCount maxLength={100} />
                    </Form.Item>

                </Col>
            </Row>


        </Form>
    );
};
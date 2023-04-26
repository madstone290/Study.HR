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
import { forwardRef, useContext, useEffect, useImperativeHandle, useRef, useState } from 'react';
import { Employee, SalaryType } from '../../data/employee';
import FormItem from 'antd/es/form/FormItem';
import { AntFormItemProps } from '../../props/AntFormItemProps';
const { Option } = Select;


const formItemLayout = {
    labelCol: {
        span: 8
    },
    wrapperCol: {
        span: 16,
    },
    scrollToFirstError: true
};

const formItems = {
    name: new AntFormItemProps({
        name: "name",
        label: "이름",
        rules: [{
            required: true,
            message: "이름을 입력하세요"
        }]
    }),
    email: new AntFormItemProps({
        name: "email",
        label: "E-mail",
        rules: [
            {
                type: 'email',
                message: 'The input is not valid E-mail!',
            },
            {
                required: true,
                message: 'Please input your E-mail!',
            }
        ]
    }),
    phoneNumberBody: new AntFormItemProps({
        name: "phoneNumberBody",
        label: "Phone Number",
        rules: [{
            required: false,
            message: 'Please input your phone number!'
        }]
    }),
    phoneNumberHead: new AntFormItemProps({
        name: "phoneNumberHead",
    }),
    salaryType: new AntFormItemProps({
        name: "salaryType",
        label: "급여 타입",
        rules: [{
            required: true,
            message: "급여를 선택하세요!",
        }]
    }),
    baseSalary: new AntFormItemProps({
        name: "baseSalary",
        label: "기준 급여",
        rules: [{
            required: false,
            message: '기준 급여를 입력하세요!',
        }]
    }),
    salaryCurrency: new AntFormItemProps({
        name: "salaryCurrency",
        rules: [{
            required: false,
            message: "통화를 선택하세요"
        }]
    }),
    loginId: new AntFormItemProps({
        name: "loginId",
        label: "로그인ID",
        tooltip: "로그인에 사용되는 아이디",
        rules: [{
            required: true,
            message: '아이디를 입력하세요',
            whitespace: true,
        }]
    }),
    password: new AntFormItemProps({
        name: "password",
        label: "Password",
        rules: [{
            required: true,
            message: 'Please input your password!',
        }],
        hasFeedback: true
    }),
    confirm: new AntFormItemProps({
        name: "confirm",
        label: "Confirm Password",
        dependencies: ['password'],
        hasFeedback: true,
        rules: [
            {
                required: true,
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
        ]
    }),
    enteredDateAsDate: new AntFormItemProps({
        name: "enteredDateAsDate",
        label: "입사일",
        rules: [{
            required: true,
            message: "입사일을 선택하세요"
        }]
    }),
    desc: new AntFormItemProps({
        name: "desc",
        label: "설명"
    })
}

export class EmployeeFormProps {
    /**
     * 사원 초기값
     */
    employee = Employee.empty();
}

export const EmployeeForm = forwardRef((props, ref) => {
    const { employee } = props;
    const employeeRef = useRef(employee);
    const [form] = Form.useForm();

    useEffect(() => {
        employeeRef.current = employee;
        form.resetFields();
        form.setFieldsValue(employee);
    }, [employee])

    useImperativeHandle(ref, () => {
        return {
            validate: async () => {
                try {
                    await form.validateFields()
                    return [true, employeeRef.current];
                } catch {
                    return [false, employeeRef.current];
                }
            }
        }
    });

    const onFormValueChanged = (changedValues, values) => {
        const [key, value] = Object.entries(changedValues)[0]

        employeeRef.current[key] = value;
        if (key == formItems.enteredDateAsDate.name && value) {
            employeeRef.current.enteredDateAsString = value.format("YYYY-MM-DD");
        }
        else if (key == formItems.phoneNumberHead.name || key == formItems.phoneNumberBody.name) {
            employeeRef.current.mergePhoneNumber();
        }
    };

    return (
        <Form {...formItemLayout}
            form={form}
            name="register"
            onValuesChange={onFormValueChanged}>
            <Row>
                <Col span={12}>
                    <Form.Item {...formItems.name}>
                        <Input />
                    </Form.Item>
                </Col>
                <Col span={12}>
                    <Form.Item {...formItems.email}>
                        <Input />
                    </Form.Item>
                </Col>
            </Row>

            <Row>
                <Col span={12}>
                    <Form.Item {...formItems.salaryType}>
                        <Select placeholder="급여 타입을 선택하세요">
                            <Option value={SalaryType.Monthly}>월급</Option>
                            <Option value={SalaryType.Weekly}>주급</Option>
                            <Option value={SalaryType.Hourly}>시급</Option>
                        </Select>
                    </Form.Item>
                </Col>
                <Col span={12}>
                    <Form.Item {...formItems.phoneNumberBody}>
                        <Input
                            addonBefore={
                                <Form.Item  {...formItems.phoneNumberHead} noStyle>
                                    <Select style={{ width: 70 }}>
                                        <Option value="010">010</Option>
                                        <Option value="011">011</Option>
                                    </Select>
                                </Form.Item>
                            }
                            style={{ width: '100%', }}
                        />
                    </Form.Item>

                </Col>
            </Row>

            <Row>
                <Col span={12}>
                    <Form.Item {...formItems.baseSalary}>
                        <InputNumber
                            addonAfter={
                                <Form.Item {...formItems.salaryCurrency} noStyle>
                                    <Select style={{ width: 70 }}>
                                        <Option value="WON">₩</Option>
                                        <Option value="USD">$</Option>
                                        <Option value="CNY">¥</Option>
                                    </Select>
                                </Form.Item>
                            }
                            style={{ width: '100%' }}
                        />
                    </Form.Item>

                </Col>
                <Col span={12}>
                    <Form.Item {...formItems.loginId}>
                        <Input />
                    </Form.Item>
                </Col>
            </Row>

            <Row>
                <Col span={12}>
                    <Form.Item {...formItems.password}>
                        <Input.Password />
                    </Form.Item>
                </Col>
                <Col span={12}>
                    <Form.Item {...formItems.confirm}>
                        <Input.Password />
                    </Form.Item>
                </Col>
            </Row>

            <Row>
                <Col span={12}>
                    <Form.Item {...formItems.enteredDateAsDate}>
                        <DatePicker style={{ width: "100%" }} />
                    </Form.Item>
                </Col>
                <Col span={12}>
                    <Form.Item {...formItems.desc}>
                        <Input.TextArea showCount maxLength={100} />
                    </Form.Item>

                </Col>
            </Row>


        </Form>
    );
});
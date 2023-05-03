import { EmployeeModel, SalaryType } from "Models/EmployeeModel";
import { DatePicker, Col, Form, Input, InputNumber, Row, Select, } from "antd";
import { forwardRef, useContext, useEffect, useImperativeHandle, useRef, useState } from "react";
const { Option } = Select;

export interface EmployeeFormProps {
    /**
     * 사원 초기값
     */
    employee: EmployeeModel
}

export interface EmployeeFormHandle {
    validate: () => Promise<[boolean, EmployeeModel]>
}

export const EmployeeForm = forwardRef<EmployeeFormHandle, EmployeeFormProps>((props, ref) => {
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

    const onFormValueChanged = (changedValues: any, values: any) => {
        const [key, value] = Object.entries(changedValues)[0]

        employeeRef.current[key] = value;
        // if (key == formItems.enteredDateAsDate.name && value) {
        //     employeeRef.current.enteredDateAsString = value.format("YYYY-MM-DD");
        // }
    };

    return (
        <Form scrollToFirstError
            labelCol={{ span: 8 }}
            wrapperCol={{ span: 16 }}
            form={form}
            name="register"
            onValuesChange={onFormValueChanged}>
            <Row>
                <Col span={12}>
                    <Form.Item name="name" label="이름" rules={[{ required: true, message: "이름을 입력하세요" }]}>
                        <Input />
                    </Form.Item>
                </Col>
                <Col span={12}>
                    <Form.Item name="name" label="E-mail" rules={[{ required: true, message: "이메일을 입력하세요" }, { type: "email", message: "유효한 이메일 형식이 아닙니다" }]}>
                        <Input />
                    </Form.Item>
                </Col>
            </Row>

            <Row>
                <Col span={12}>
                    <Form.Item name="salaryType" label="급여 타입" rules={[{ required: true, message: "급여를 선택하세요!" }]}>
                        <Select placeholder="급여 타입을 선택하세요">
                            <Option value={SalaryType.Monthly}>월급</Option>
                            <Option value={SalaryType.Weekly}>주급</Option>
                            <Option value={SalaryType.Hourly}>시급</Option>
                        </Select>
                    </Form.Item>
                </Col>
                <Col span={12}>
                    <Form.Item name="phoneNumberBody" label="Phone Number">
                        <Input
                            addonBefore={
                                <Form.Item name={"phoneNumberHead"} noStyle>
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
                    <Form.Item name="p1" label="P1">
                        <InputNumber
                            addonAfter={
                                <Form.Item name="p2" label="P2" noStyle>
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
                    <Form.Item>
                        <Input />
                    </Form.Item>
                </Col>
            </Row>

            <Row>
                <Col span={12}>
                    <Form.Item>
                        <Input.Password />
                    </Form.Item>
                </Col>
                <Col span={12}>
                    <Form.Item>
                        <Input.Password />
                    </Form.Item>
                </Col>
            </Row>

            <Row>
                <Col span={12}>
                    <Form.Item>
                        <DatePicker style={{ width: "100%" }} />
                    </Form.Item>
                </Col>
                <Col span={12}>
                    <Form.Item>
                        <Input.TextArea showCount maxLength={100} />
                    </Form.Item>

                </Col>
            </Row>


        </Form >
    );
});
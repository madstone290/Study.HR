import {
    DatePicker,
    Col,
    Form,
    Input,
    InputNumber,
    Row,
    Select,
} from 'antd';
import { useEffect, useRef, useState } from 'react';

const formItemLayout = {
    labelCol: {
        span: 8
    },
    wrapperCol: {
        span: 16,
    },
};

export function DepartmentForm({ initialDepartment }) {
    console.log("Rendering DepartmentForm");
    const [form] = Form.useForm();
    const employeeRef = useRef(initialDepartment);

    useEffect(() => {
        form.resetFields();
        form.setFieldsValue(initialDepartment);
        employeeRef.current = initialDepartment;
    }, [initialDepartment])


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
                    <Form.Item name="code"
                        label="코드"
                        rules={[
                            {
                                required: true,
                                message: "코드를 입력하세요",
                            },
                        ]}
                    >
                        <Input />
                    </Form.Item>
                </Col>
                <Col span={12}>
                    <Form.Item name="name"
                        label="이름"
                        rules={[
                            {
                                required: true,
                                message: "이름을 입력하세요",
                            },
                        ]}
                    >
                        <Input />
                    </Form.Item>
                </Col>
            </Row>




        </Form>
    );
};
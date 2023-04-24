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
import { Department } from '../../data/department';

const formItemLayout = {
    labelCol: {
        span: 8
    },
    wrapperCol: {
        span: 16,
    },
};

export function DepartmentForm({ initialDepartment, isReady, onValidate }) {
    const [form] = Form.useForm();
    const departmentRef = useRef(Department.new());

    useEffect(() => {
        form.resetFields();
        form.setFieldsValue(initialDepartment);
    }, [initialDepartment]);


    const validate = async () => {
        let valid = false;
        try {
            await form.validateFields();
            valid = true;
        } catch (err) {
            console.log(err);
        }
        onValidate(valid, departmentRef.current);
    }

    useEffect(() => {
        if (isReady)
            validate();
    })

    const formValueChanged = (changedValues, values) => {
        const [key, value] = Object.entries(changedValues)[0]
        departmentRef.current[key] = value;
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
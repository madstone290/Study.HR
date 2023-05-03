import { Col, Form, Input, Row } from "antd";
import { forwardRef, useEffect, useImperativeHandle, useRef, useState } from "react";
import { DepartmentModel } from "Models/DepartmentModel";

export interface DepartmentFormProps {
    department: DepartmentModel;
}

export interface DepartmentFormHandle {
    validate: () => Promise<[boolean, DepartmentModel]>
}

export const DepartmentForm = forwardRef<DepartmentFormHandle, DepartmentFormProps>((props, ref) => {
    const [form] = Form.useForm();
    const departmentRef = useRef(props.department);

    useEffect(() => {
        form.resetFields();
        form.setFieldsValue(props.department);
    }, [props.department]);

    useImperativeHandle(ref, () => {
        return {
            validate: async () => {
                try {
                    await form.validateFields()
                    return [true, departmentRef.current];
                } catch {
                    return [false, departmentRef.current];
                }
            }
        }
    });

    const formValueChanged = (changedValues: any, values: any) => {
        const [key, value] = Object.entries(changedValues)[0];
        departmentRef.current[key] = value;
    };

    return (
        <Form form={form}
            labelCol={{ span: 8 }}
            wrapperCol={{ span: 16 }}
            name="register"
            onValuesChange={formValueChanged}
            scrollToFirstError>
            <Row>
                <Col span={12}>
                    <Form.Item name="code" label="코드"
                        rules={[{
                            required: true,
                            message: "코드를 입력하세요",
                        }]}>
                        <Input />
                    </Form.Item>
                </Col>
                <Col span={12}>
                    <Form.Item name="name" label="이름"
                        rules={[{
                            required: true,
                            message: "이름을 입력하세요"
                        }]}>
                        <Input />
                    </Form.Item>
                </Col>
            </Row>
        </Form >
    );
});
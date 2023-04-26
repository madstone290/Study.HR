import {
    DatePicker,
    Col,
    Form,
    Input,
    InputNumber,
    Row,
    Select,
} from 'antd';
import { forwardRef, useEffect, useImperativeHandle, useRef, useState } from 'react';
import { AntFormItemProps } from '../../props/AntFormItemProps';

const formItemLayout = {
    labelCol: {
        span: 8
    },
    wrapperCol: {
        span: 16,
    },
};

const formItems = {
    code: new AntFormItemProps({
        name: "code",
        label: "코드",
        rules: [{
            required: true,
            message: "코드를 입력하세요",
        }]
    }),
    name: new AntFormItemProps({
        name: "name",
        label: "이름",
        rules: [{
            required: true,
            message: "이름을 입력하세요",
        }]
    })
};

export const DepartmentForm = forwardRef((props, ref) => {
    const { department } = props;
    const [form] = Form.useForm();
    const departmentRef = useRef(department);

    useEffect(() => {
        form.resetFields();
        form.setFieldsValue(department);
    }, [department]);

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
                    <Form.Item {...formItems.code}>
                        <Input />
                    </Form.Item>
                </Col>
                <Col span={12}>
                    <Form.Item {...formItems.name}>
                        <Input />
                    </Form.Item>
                </Col>
            </Row>
        </Form>
    );
});
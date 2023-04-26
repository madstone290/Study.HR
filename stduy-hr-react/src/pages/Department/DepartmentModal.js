import { Modal } from "antd"
import { useState, useEffect, useRef, useReducer } from "react";
import { DepartmentForm } from "./DepartmentForm";
import { Department } from "../../data/department";
import { departmentApi } from "../../api/department-api";

export function DepartmentModal({ showModal, onClosed }) {
    const [modalOpen, setModalOpen] = useState(false);
    const formRef = useRef();

    useEffect(() => {
        if (showModal) {
            setModalOpen(showModal);
        }
    }, [showModal])

    const close = () => {
        setModalOpen(false);
        onClosed();
    }

    const handleModalOk = async () => {
        const [valid, department] = await formRef.current.validate();
        if (valid) {
            //TODO api call
            console.log("model is valid");
            close();
        } else {
            alert("model is not valid");
        }

    }

    const handleModalCancel = () => {
        close();
    };

    const departmentFormProps = {
        department: Department.new()
    };

    return (
        <Modal title="부서 추가" open={modalOpen}
            width={1000}
            maskClosable={false}
            onOk={handleModalOk}
            onCancel={handleModalCancel}>
            <DepartmentForm ref={formRef} {...departmentFormProps} />
        </Modal>
    );
}
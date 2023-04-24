import { Modal } from "antd"
import { useState, useEffect, useRef, useReducer } from "react";
import { DepartmentForm } from "./DepartmentForm";
import { Department } from "../../data/department";
import { departmentApi } from "../../api/department-api";

export function DepartmentModal({ showModal, onClosed }) {
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [isReady, setIsReady] = useState(false);
    const departmentRef = useRef(Department.new());

    useEffect(() => {
        if (showModal) {
            setIsModalOpen(showModal);
            departmentRef.current = Department.new();
        }
    }, [showModal])

    const handleValidate = async (valid, obj) => {
        if (valid) {
            await departmentApi.addDepartment(obj);
            close();
        }
        else {
            alert("not valid...");
        }
        setIsReady(false);
    }

    const close = () => {
        setIsModalOpen(false);
        onClosed();
    }


    const handleModalOk = async () => {
        setIsReady(true);
    }

    const handleModalCancel = () => {
        close();
    };

    return (
        <Modal title="부서 추가" open={isModalOpen}
            width={1000}
            maskClosable={false}
            onOk={handleModalOk}
            onCancel={handleModalCancel}>
            <DepartmentForm initialDepartment={departmentRef.current} isReady={isReady} onValidate={handleValidate} />
        </Modal>
    );
}
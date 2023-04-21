import { Modal } from "antd"
import { useState, useEffect, useRef, useReducer } from "react";

export function DepartmentModal({ showModal, handleClosed }) {
    console.log("Rendering DepartmentModal");
    const [isModalOpen, setIsModalOpen] = useState(false);

    useEffect(() => {
        if (showModal)
            setIsModalOpen(showModal);
        console.log("showModal is changed");
    }, [showModal])

    const handleModalOk = async () => {
        setIsModalOpen(false);
        handleClosed();
    }

    const handleModalCancel = () => {
        setIsModalOpen(false);
        handleClosed();
    };

    return (
        <Modal title="부서 추가" open={isModalOpen}
            width={1000}
            maskClosable={false}
            onOk={handleModalOk}
            onCancel={handleModalCancel}>
        </Modal>
    );
}
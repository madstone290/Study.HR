import { Modal } from "antd"
import { useState, useEffect, useRef } from "react";
import { DepartmentForm, DepartmentFormHandle, DepartmentFormProps } from "./DepartmentForm";
import { DepartmentModel } from "Models/DepartmentModel";

export interface DepartmentModalProps {
    readonly showModal: boolean;
    readonly onClosed: () => void;
}

export function DepartmentModal(props: DepartmentModalProps) {
    const [modalOpen, setModalOpen] = useState(false);
    const departmentFormHandle = useRef<DepartmentFormHandle>(null);

    useEffect(() => {
        if (props.showModal) {
            setModalOpen(props.showModal);
        }
    }, [props.showModal])

    const close = () => {
        setModalOpen(false);
        props.onClosed();
    }

    const handleModalOk = async () => {
        if (departmentFormHandle.current) {
            const [valid, department] = await departmentFormHandle.current.validate();
            if (valid) {
                //TODO api call
                console.log("department is valid", department);
                close();
            } else {
                alert("model is not valid");
            }
        }
    }

    const handleModalCancel = () => {
        close();
    };

    return (
        <Modal title="부서 추가" open={modalOpen}
            width={1000}
            maskClosable={false}
            onOk={handleModalOk}
            onCancel={handleModalCancel}>
            <DepartmentForm ref={departmentFormHandle} department={DepartmentModel.empty()} />
        </Modal>
    );
}
import { Modal } from "antd"
import { useState, useEffect, useRef, useReducer } from "react";
import { EmployeeForm } from "./EmployeeForm";
import { Employee } from "../../data/employee";
import { addEmployee } from "../../api/employee-api";


export function EmployeeModal({ bindEmployeeModalState }) {
    console.log("Rendering MyModal");
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [employee, setEmployee] = useState(Employee.empty());
    
    const validateRef = useRef();
    const bindEmployeeFormState = (formState) => {
        const { validate } = formState;
        validateRef.current = validate;
    }

    useEffect(() => {
        const state = {
            modalOpener: () => {
                setIsModalOpen(true);
                setEmployee(Employee.empty());
            }
        };
        bindEmployeeModalState(state);
    }, [bindEmployeeFormState, isModalOpen]);

    const handleModalOk = async () => {
        if (await validateRef.current()) {
            
            if(await addEmployee(employee))
                setIsModalOpen(false);
            else
                alert("error!");
        }
    }

    const handleModalCancel = () => {
        setIsModalOpen(false);
    };

    return (
        <Modal title="사원 추가" open={isModalOpen}
            width={1000}
            maskClosable={false}
            onOk={handleModalOk}
            onCancel={handleModalCancel}>
            <EmployeeForm initialEmployee={employee} bindState={bindEmployeeFormState} />
        </Modal>
    );
}
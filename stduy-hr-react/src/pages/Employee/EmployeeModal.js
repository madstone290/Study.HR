import { Modal } from "antd"
import { useState, useEffect, useRef, useReducer, useContext } from "react";
import { EmployeeForm, EmployeeFormProps } from "./EmployeeForm";
import { Employee } from "../../data/employee";
import { addEmployee } from "../../api/employee-api";
import { EmployeeContext } from "./EmployeeContext";

export function EmployeeModal() {
    const contextValue = useContext(EmployeeContext);
    const { modalOpen, setModalOpen } = contextValue;

    const formRef = useRef();

    const handleModalOk = async () => {

        const [valid, employee] = await formRef.current.validate();
        if (valid) {
            const apiResult = await addEmployee(employee);
            if (apiResult.isSuccessful) {
                setModalOpen(false);
            } else {
                alert(apiResult.message);
            }
        }
    }

    const handleModalCancel = () => {
        setModalOpen(false);
    };

    const employeeFormProps = new EmployeeFormProps();
    employeeFormProps.employee = new Employee("Jack");

    return (
        <Modal title="사원 추가" open={modalOpen}
            width={1000}
            maskClosable={false}
            onOk={handleModalOk}
            onCancel={handleModalCancel}>
            <EmployeeForm {...employeeFormProps} ref={formRef} />
        </Modal>
    );
}


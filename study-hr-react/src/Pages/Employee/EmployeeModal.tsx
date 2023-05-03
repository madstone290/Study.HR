import { Modal } from "antd"
import { useRef } from "react";
import { EmployeeForm, EmployeeFormHandle } from "./EmployeeForm";
import { useEmployeeContext } from "./EmployeeContext";
import { EmployeeModel } from "Models/EmployeeModel";
import { EmployeeApi, EmployeeDto } from "Services/Api/EmployeeApi";

export function EmployeeModal() {
    const emplpyeeContextValue = useEmployeeContext();
    const { modalOpen, setModalOpen } = emplpyeeContextValue;

    const formRef = useRef<EmployeeFormHandle>(null);

    const handleModalOk = async () => {
        if (!formRef.current)
            return;

        const [valid, employee] = await formRef.current.validate();
        if (valid) {
            const apiResult = await new EmployeeApi().addEmployee({ ...employee } as EmployeeDto);
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


    return (
        <Modal title="사원 추가" open={modalOpen}
            width={1000}
            maskClosable={false}
            onOk={handleModalOk}
            onCancel={handleModalCancel}>
            <EmployeeForm ref={formRef} employee={EmployeeModel.empty()} />
        </Modal>
    );
}


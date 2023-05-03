import { Table, Button } from "antd";
import type { ColumnsType } from "antd/es/table";
import { useTableAutoSize } from "Hooks/useTableAutoSize";
import { EmployeeModel, employeeList } from "Models/EmployeeModel";
import { useState, useEffect, useRef, CSSProperties, MouseEventHandler, useContext, MutableRefObject } from "react";
import { EmployeeApi } from "Services/Api/EmployeeApi";
import { EmployeeContext, EmployeeContextValue } from "./EmployeeContext";
import { EmployeeModal } from "./EmployeeModal";

const columns: ColumnsType<EmployeeModel> = [
    { title: "아이디", dataIndex: 'id' },
    {
        title: '코드', dataIndex: 'code',
        render: (value) => <a>{value}</a>
    },
    { title: '이름', dataIndex: 'name' },
    { title: '주소', dataIndex: 'address' },
    { title: '이메일', dataIndex: 'email' },
];

export function EmployeeList() {
    const [employees, setEmployees] = useState<EmployeeModel[]>([]);
    const [modalOpen, setModalOpen] = useState(false);
    const tableRef = useRef<HTMLDivElement>();
    const tableHeight = useTableAutoSize(tableRef);

    const loadData = async () => {
        const apiResult = await new EmployeeApi().getEmployees();
        if (apiResult.isSuccessful)
            setEmployees(apiResult.data as EmployeeModel[]);
        else {
            setEmployees(employeeList);
            console.log(apiResult.message);
        }
    };

    const handleNewClick = () => {
        setModalOpen(true);
    };
    const handleLoadDataClick = () => {
        loadData();
    }

    useEffect(() => {
        loadData();
    }, []);


    const menuProps: MenuProps = {
        onNewClick: handleNewClick,
        onLoadClick: handleLoadDataClick
    };

    const contextValue: EmployeeContextValue = {
        modalOpen: modalOpen,
        setModalOpen: (open) => setModalOpen(open)
    };
    console.log(contextValue);
    return (
        <EmployeeContext.Provider value={contextValue}>
            <div style={{ display: "flex", flexDirection: "column", height: "100%" }}>
                <Menu {...menuProps} />
                <Table style={{ flex: "1" }}
                    pagination={false}
                    ref={tableRef as React.Ref<HTMLDivElement>}
                    scroll={{ x: 1000, y: tableHeight }}
                    columns={columns}
                    dataSource={employees} />
            </div>
            <EmployeeModal />
        </EmployeeContext.Provider>
    );
}



interface MenuProps {
    onNewClick: React.MouseEventHandler<HTMLAnchorElement> & React.MouseEventHandler<HTMLButtonElement>;
    onLoadClick: React.MouseEventHandler<HTMLAnchorElement> & React.MouseEventHandler<HTMLButtonElement>;
}

const Menu = (props: MenuProps) => {
    const basicStyle: CSSProperties = {
        textAlign: "start"
    }

    const { onNewClick, onLoadClick } = props;
    return (
        <div style={basicStyle}>
            <Button onClick={onNewClick}>
                추가
            </Button>
            <Button onClick={onLoadClick}>
                조회
            </Button>
        </div>
    );
};

import { DatePicker, Table, Tag, Divider, Button, Modal, Row, Col } from 'antd';
import { Resizable } from 'react-resizable';
import { useEffect, useLayoutEffect, useRef, useState } from 'react';
import { Employee, employeeList } from "../../data/employee";
import { EmployeeModal, EmployeeModalProps } from "./EmployeeModal"
import { useTableAutoSize } from '../../hooks/useTableAutoSize';
import { getEmployees } from '../../api/employee-api';
import { EmployeeContext, EmployeeContextValue } from './EmployeeContext';
import { AntColumnProps } from '../../props/AntColumnProps';

const columns = [
    new AntColumnProps({ title: "이름", dataIndex: "name", render: (value) => <a>{value}</a> }),
    new AntColumnProps({ title: "입사일", dataIndex: "enteredDateAsString" }),
    new AntColumnProps({ title: "생년월일", dataIndex: "dateOfBirthAsString" }),
    new AntColumnProps({ title: "주소", dataIndex: "address" }),
    new AntColumnProps({ title: "로그인아이디", dataIndex: "loginId" }),
    new AntColumnProps({ title: "로그인비밀번호", dataIndex: "loginPassword" }),
    new AntColumnProps({ title: "이메일", dataIndex: "email" }),
    new AntColumnProps({ title: "휴대폰", dataIndex: "phoneNumber" }),
    new AntColumnProps({ title: "급여타입", dataIndex: "salaryType" }),
    new AntColumnProps({ title: "기본급여", dataIndex: "baseSalary" }),
    new AntColumnProps({ title: "통화", dataIndex: "salaryCurrency" }),
    new AntColumnProps({ title: "설명", dataIndex: "desc" }),
    new AntColumnProps({ title: "등급", dataIndex: "rate" }),
    new AntColumnProps({ title: "관리자", dataIndex: "isAdmin", render: (value) => <span>{value ? "O" : ""}</span> })
];

// rowSelection object indicates the need for row selection
const rowSelection = {
    onChange: (selectedRowKeys, selectedRows) => {
        console.log(`selectedRowKeys: ${selectedRowKeys}`, 'selectedRows: ', selectedRows);
    },
    getCheckboxProps: record => ({
        disabled: record.isAdmin === true, // Column configuration not to be checked
        name: record.name,
    }),
};

const pagenation = {
    pageSize: 100,
    disabled: true
};


export function EmployeeListView() {
    const [employees, setEmployees] = useState([]);
    const [modalOpen, setModalOpen] = useState(false);

    const loadData = async () => {
        const apiResult = await getEmployees();
        if (apiResult.isSuccessful)
            setEmployees(apiResult.data);
        else {
            alert(apiResult.message);
            setEmployees(employeeList);
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

    const tableRef = useRef(null);
    const tableHeight = useTableAutoSize(tableRef);

    const menuProps = new MenuProps();
    menuProps.onNewClick = handleNewClick;
    menuProps.onLoadClick = handleLoadDataClick;

    const contextValue = new EmployeeContextValue();
    contextValue.modalOpen = modalOpen;
    contextValue.setModalOpen = setModalOpen;

    return (
        <EmployeeContext.Provider value={contextValue}>
            <div style={{ display: "flex", flexDirection: "column", height: "100%" }}>
                <Menu {...menuProps} />
                <Table style={{ flex: "1" }}
                    ref={tableRef}
                    scroll={{ x: 1000, y: tableHeight }}
                    rowSelection={rowSelection}
                    pagination={pagenation}
                    columns={columns}
                    dataSource={employees} />
                <EmployeeModal />
            </div>
        </EmployeeContext.Provider>


    );
}



class MenuProps {

    /**
     * 
     * 추가버튼 클릭
     * @param {Event} e
     */
    onNewClick = (e) => { };

    /**
     * 조회버튼 클릭
     * @param {Event} e 
     */
    onLoadClick = (e) => { };

}



/**
 * @param {MenuProps} props 
 */
const Menu = (props) => {
    const basicStyle = {
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

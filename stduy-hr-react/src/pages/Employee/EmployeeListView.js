import { DatePicker, Table, Tag, Divider, Button, Modal } from 'antd';
import { Resizable } from 'react-resizable';
import { useEffect, useLayoutEffect, useRef, useState } from 'react';
import { Employee, employeeList } from "../../data/employee";
import { config } from "../../config"
import { EmployeeModal } from "./EmployeeModal"
import { useTableAutoSize } from '../../hooks/useTableAutoSize';
import { getEmployees } from '../../api/employee-api';

class AntColumn {
    title = "";
    dataIndex = "";
    render = (value) => { }

    constructor(title, dataIndex, render) {
        this.title = title;
        this.dataIndex = dataIndex;
        this.render = render;
    }
}

const columns = [
    new AntColumn("이름", "name", (value) => <a>{value}</a>),
    new AntColumn("입사일", "enteredDateAsString"),
    new AntColumn("생년월일", "dateOfBirthAsString"),
    new AntColumn("주소", "address"),
    new AntColumn("로그인아이디", "loginId"),
    new AntColumn("로그인비밀번호", "loginPassword"),
    new AntColumn("이메일", "email"),
    new AntColumn("휴대폰", "phoneNumber"),
    new AntColumn("급여타입", "salaryType"),
    new AntColumn("기본급여", "baseSalary"),
    new AntColumn("통화", "salaryCurrency"),
    new AntColumn("설명", "desc"),
    new AntColumn("등급", "rate"),
    new AntColumn("관리자", "isAdmin", (value) => <span>{value ? "O" : ""}</span>)
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
    console.log("rendering EmployeeListView");
    const [employees, setEmployees] = useState([]);

    const loadData = async () => {
        const apiResult = await getEmployees();
        if (apiResult.isSuccessful)
            setEmployees(apiResult.data);
        else {
            alert(apiResult.message);
            setEmployees(employeeList);
        }
    };

    let modalOpener = () => { }
    const bindEmployeeModalState = (state) => {
        modalOpener = state.modalOpener;
    };

    const handleNewClick = () => {
        modalOpener();
    };
    const handleLoadDataClick = () => {
        loadData();
    }

    useEffect(() => {
        loadData();
    }, []);

    const tableRef = useRef(null);
    const tableHeight = useTableAutoSize(tableRef);

    return (
        <div style={{ display: "flex", flexDirection: "column", height: "100%" }}>
            <div>
                <Button type="primary" onClick={handleNewClick}>
                    추가
                </Button>
                <Button type="second" onClick={handleLoadDataClick}>
                    조회
                </Button>
            </div>
            <Table style={{ flex: "1" }}
                ref={tableRef}
                scroll={{ x: 1000, y: tableHeight }}
                rowSelection={rowSelection}
                pagination={pagenation}
                columns={columns}
                dataSource={employees} />
            <EmployeeModal bindEmployeeModalState={bindEmployeeModalState} />
        </div>

    );
}



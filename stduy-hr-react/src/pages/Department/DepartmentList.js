import { DatePicker, Table, Tag, Divider, Button, Modal } from 'antd';
import { useEffect, useLayoutEffect, useRef, useState } from 'react';
import { useTableAutoSize } from '../../hooks/useTableAutoSize';

import { departmentApi } from '../../api/department-api';
import { DepartmentModal } from './DepartmentModal';




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
    new AntColumn("ID", "id"),
    new AntColumn("코드", "code", (value) => <a>{value}</a>),
    new AntColumn("이름", "name"),
    new AntColumn("상위부서ID", "upperDepartmentId")
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


export function DepartmentList() {
    console.log("rendering DepartmentList");
    const [departments, setDepartments] = useState([]);
    const [showModal, setShowModal] = useState(false);

    const loadData = async () => {
        const apiResult = await departmentApi.getDepartments();
        if (apiResult.isSuccessful)
            setDepartments(apiResult.data);
        else {
            alert(apiResult.message);
        }
    };

    const handleNewClick = () => {
        setShowModal(true);
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
                dataSource={departments} />
            <DepartmentModal showModal={showModal} handleClosed={()=>setShowModal(false)} />
        </div>

    );
}



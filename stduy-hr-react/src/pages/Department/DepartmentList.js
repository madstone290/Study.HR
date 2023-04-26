import { DatePicker, Table, Tag, Divider, Button, Modal } from 'antd';
import { useEffect, useLayoutEffect, useRef, useState } from 'react';
import { useTableAutoSize } from '../../hooks/useTableAutoSize';

import { departmentApi } from '../../api/department-api';
import { DepartmentModal } from './DepartmentModal';
import { AntColumnProps } from '../../props/AntColumnProps';

const columns = [
    new AntColumnProps({ title: "ID", dataIndex: "id" }),
    new AntColumnProps({ title: "코드", dataIndex: "code", render: (value) => <a>{value}</a> }),
    new AntColumnProps({ title: "이름", dataIndex: "name" }),
    new AntColumnProps({ title: "상위부서ID", dataIndex: "upperDepartmentId" })
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
            <DepartmentModal showModal={showModal} onClosed={() => setShowModal(false)} />
        </div>

    );
}



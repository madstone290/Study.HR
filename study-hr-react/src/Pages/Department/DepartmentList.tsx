import { useTableAutoSize } from "Hooks/useTableAutoSize";
import { DepartmentModel } from "Models/DepartmentModel";
import { DepartmentApi } from "Services/Api/DepartmentApi";
import React, { CSSProperties, useRef, useState } from "react";
import { Button, Table } from "antd";
import { ColumnsType } from 'antd/es/table';
import { DepartmentModal } from "Pages/Department/DepartmentModal"

const columnTypes: ColumnsType<DepartmentModel> = [
    {
        title: "아이디",
        dataIndex: 'id',
    },
    {
        title: '코드',
        dataIndex: 'code',
        render: (value) => <a>{value}</a>
    },
    {
        title: '이름',
        dataIndex: 'name',
    },
    {
        title: '상위부서',
        dataIndex: 'upperDepartmentId',
    },
];

export const DepartmentList = () => {
    const [departments, setDepartments] = useState<DepartmentModel[]>([]);
    const [showModal, setShowModal] = useState(false);
    const tableRef = useRef<HTMLDivElement>();
    const tableHeight = useTableAutoSize(tableRef);

    const handleNewClick = () => {
        setShowModal(true);
    };
    const handleLoadDataClick = () => {
        loadData();
    }

    const loadData = async () => {
        const apiResult = await new DepartmentApi().getDepartments();
        if (apiResult.isSuccessful)
            setDepartments(apiResult.data! as DepartmentModel[]);
        else {
            console.log(apiResult.message);
        }
    };

    return (
        <div style={{ display: "flex", flexDirection: "column", height: "100%" }}>
            <Menu onNewClick={handleNewClick} onLoadClick={handleLoadDataClick} />
            <Table style={{ flex: "1" }}
                ref={tableRef as React.Ref<HTMLDivElement>}
                scroll={{ x: 1000, y: tableHeight }}
                columns={columnTypes}
                dataSource={departments} />
            <DepartmentModal showModal={showModal} onClosed={() => { setShowModal(false); }} />
        </div>

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
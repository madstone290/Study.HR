import { Layout, Menu, theme } from 'antd';
import { UserOutlined } from '@ant-design/icons';
import { Link } from "react-router-dom";
import { useCallback } from 'react';
import { ItemInfo } from './item-info';

const siderStyle = {
    width: "200px",
    background: "",
}

const menuStyle = {
    height: '100%',
    borderRight: 0,
}
const items = [
    new ItemInfo("000", "샘플", <UserOutlined />, [
        new ItemInfo("001", <Link to="modal">모달</Link>),
        new ItemInfo("002", <Link to="form">폼</Link>),    
    ]),
    new ItemInfo("100", <Link to="/">Home</Link>, <UserOutlined />),
    new ItemInfo("200", "기초코드", <UserOutlined />, [
        new ItemInfo("201", <Link to="/departments">부서</Link>, <UserOutlined />),
        new ItemInfo("202", <Link to="/employeelist">사원</Link>, <UserOutlined />)
    ]),
    new ItemInfo("300", "근태", <UserOutlined />, [
        new ItemInfo("301", <Link to="/">출퇴근</Link>, <UserOutlined />),
        new ItemInfo("302", <Link to="/">연차</Link>, <UserOutlined />)
    ]),
    new ItemInfo("400", "급여", <UserOutlined />, [
        new ItemInfo("401", <Link to="/">급여명세</Link>, <UserOutlined />),
        new ItemInfo("402", <Link to="/">보너스</Link>, <UserOutlined />),
        new ItemInfo("410", <Link to="/">공제</Link>, <UserOutlined />, [
            new ItemInfo("411", <Link to="/">보험</Link>, <UserOutlined />),
            new ItemInfo("412", <Link to="/">주택</Link>, <UserOutlined />),
        ]),
    ]),
];

export function LeftMenu({ collapsed = false }) {
    const {
        token: { colorBgContainer },
    } = theme.useToken();
    siderStyle.background = colorBgContainer;

    return (
        <Layout.Sider style={siderStyle} collapsed={collapsed}>
            <Menu style={menuStyle} items={items} mode="inline" defaultSelectedKeys={['1']}
                defaultOpenKeys={['sub1']}>
            </Menu>
        </Layout.Sider>
    );
}




import { Layout, Menu, theme } from 'antd';
import { UserOutlined } from '@ant-design/icons';
import { Link } from "react-router-dom";
import { ItemType } from "antd/es/menu/hooks/useItems"
import { PageRoute } from "Routes/PageRoute";
import styles from "Layouts/Css/VerticalMenu.module.css"
import { CSSProperties } from 'react';

const items: ItemType[] = [
    { key: "100", label: <Link to="/">Home</Link>, icon: < UserOutlined /> },
    {
        key: "200", label: "기초코드", icon: < UserOutlined />, children: [
            { key: "201", label: <Link to={PageRoute.DEPARTMENTS}>부서</Link>, icon: < UserOutlined /> },
            { key: "202", label: <Link to={PageRoute.EMPLOYEES}>사원</Link>, icon: < UserOutlined /> }
        ]
    },
    {
        key: "300", label: "근태", icon: <UserOutlined />, children: [
            { key: "301", label: <Link to="/">출퇴근</Link>, icon: < UserOutlined /> },
            { key: "302", label: <Link to="/">연차</Link>, icon: < UserOutlined /> }
        ],
    },
    {
        key: "400", label: "급여", icon: < UserOutlined />, children: [
            { key: "401", label: <Link to="/">급여명세</Link>, icon: < UserOutlined /> },
            { key: "402", label: <Link to="/">보너스</Link>, icon: < UserOutlined /> },
            {
                key: "410", label: <Link to="/">공제</Link>, icon: < UserOutlined />, children: [
                    { key: "411", label: <Link to="/">보험</Link>, icon: < UserOutlined /> },
                    { key: "412", label: <Link to="/">주택</Link>, icon: < UserOutlined /> },
                ]
            }
        ]
    },
];

export function VerticalMenu({ collapsed = false }) {
    const {
        token: { colorBgContainer },
    } = theme.useToken();
    const colorStyle: CSSProperties = {
        backgroundColor: colorBgContainer
    }
    return (
        <Layout.Sider className={styles.siderStyle} style={colorStyle} collapsed={collapsed}>
            <Menu className={styles.menuStyle} items={items} mode="inline" defaultSelectedKeys={['1']}
                defaultOpenKeys={['sub1']}>
            </Menu>
        </Layout.Sider>
    );
}




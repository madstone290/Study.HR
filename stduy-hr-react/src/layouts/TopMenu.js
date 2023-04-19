import logo from '../logo.svg';
import { Layout, Menu, Button } from 'antd';
import { HomeOutlined, EditOutlined, MenuOutlined, UserOutlined } from '@ant-design/icons';
import { useCallback } from 'react';
import { ItemInfo } from './item-info';

const containerStyle = {
    display: "flex",
    flexDirection: "row",
    padding: "0px 6px",
    height: "46px"
};

const leftContainerStyle = {
    display: "flex",
    flexDirection: "row",
    flex: 0.5
};
const logoStyle = {
    alignSelf: "center"
};
const menuContainerStyle = {
    flex: 1,
    alignSelf: "flex-end"
};
const menuStyle = {
    justifyContent: "flex-end"
};
const toggleBtnStyle = {
    alignSelf: "center"
};

const items = [
    new ItemInfo("100", "기본", <HomeOutlined />),
    new ItemInfo("200", "관리자", <UserOutlined />),
    new ItemInfo("300", "설정", <EditOutlined />),
    new ItemInfo("400", "시스템", <EditOutlined />)
];

export function TopMenu({ onToggleClick }) {
    const onToggleClickCallback = useCallback(event => {
        onToggleClick();
    }, [onToggleClick])

    return (
        <div style={containerStyle}>
            <div style={leftContainerStyle}>
                <Button style={toggleBtnStyle} onClick={onToggleClickCallback}><MenuOutlined /></Button>
                <img src={logo} />
                <div style={logoStyle}>로고</div>
            </div>
            <div style={menuContainerStyle}>
                <Menu mode="horizontal" style={menuStyle} items={items}>
                </Menu>
            </div>
        </div>
    );
}
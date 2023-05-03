import logo from '../logo.svg';
import { Menu, Button } from "antd";
import { HomeOutlined, EditOutlined, MenuOutlined, UserOutlined } from "@ant-design/icons";
import { useCallback } from "react";
import { ItemType } from "antd/es/menu/hooks/useItems"
import styles from "Layouts/Css/HorizontalMenu.module.css"

const items: ItemType[] = [
    {
        key: "100",
        label: "기본",
        icon: <HomeOutlined />
    },
    {
        key: "200",
        label: "관리자",
        icon: <UserOutlined />
    },
    {
        key: "300",
        label: "설정",
        icon: <EditOutlined />
    },
    {
        key: "400",
        label: "시스템",
        icon: <EditOutlined />
    },
];


interface HorizontalMenuProps {
    /**
     * 메뉴토클 버튼 클릭
     * @returns 
     */
    onMenuToggleBtnClicked: () => void;
}

export function HorizontalMenu(pros: HorizontalMenuProps) {
    const onToggleClickCallback = useCallback(() => pros.onMenuToggleBtnClicked(), [pros.onMenuToggleBtnClicked]);

    return (
        <div className={styles.containerStyle}>
            <div className={styles.leftContainerStyle}>
                <Button className={styles.toggleBtnStyle} onClick={onToggleClickCallback}><MenuOutlined /></Button>
                <img src={logo} />
                <div className={styles.logoStyle}>로고</div>
            </div>
            <div className={styles.menuContainerStyle}>
                <Menu mode="horizontal" className={styles.menuStyle} items={items}>
                </Menu>
            </div>
        </div>
    );
}
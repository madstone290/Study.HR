import { CSSProperties, useState } from "react";
import { Layout } from "antd";
import { HorizontalMenu } from "Layouts/HorizontalMenu";
import { VerticalMenu } from "Layouts/VerticalMenu";
import { MainContent } from "Layouts/MainContent";
import styles from "Layouts/Css/BaseLayout.module.css"

export function BaseLayout() {
    const [leftMenuCollapsed, setLeftMenuCollapsed] = useState(false);
    const handleToggleClick = () => {
        setLeftMenuCollapsed(!leftMenuCollapsed);
    };
    const layoutStyle: CSSProperties = {
        height: "100vh"
    }

    return (
        <Layout className={styles.layout}>
            <HorizontalMenu onMenuToggleBtnClicked={handleToggleClick} />
            <Layout>
                <VerticalMenu collapsed={leftMenuCollapsed} />
                <MainContent />
            </Layout>
        </Layout>
    );
};
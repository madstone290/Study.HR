import { Layout } from "antd";
import { CSSProperties } from "react";
import { Outlet } from "react-router-dom";
import styles from "Layouts/Css/MainContent.module.css"

export function MainContent() {
    return (
        <Layout className={styles.layoutStyle}>
            <Layout.Content className={styles.contentStyle}>
                <Outlet />
            </Layout.Content>
        </Layout>
    );
}
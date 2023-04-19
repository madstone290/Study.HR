import { Layout } from 'antd';
import React, { useState } from 'react';
import { TopMenu } from './layouts/TopMenu';
import { LeftMenu } from './layouts/LeftMenu';
import { MainContent } from './layouts/MainContent';


export function BaseLayout() {
    const [leftMenuCollapsed, setLeftMenuCollapsed] = useState(false);
    const handleToggleClick = () => {
        setLeftMenuCollapsed(!leftMenuCollapsed);
    };
    return (
        <Layout style={{ height: "100vh" }}>
            <TopMenu onToggleClick={handleToggleClick} />
            <Layout>
                <LeftMenu collapsed={leftMenuCollapsed} />
                <MainContent />
            </Layout>
        </Layout>
    );
};
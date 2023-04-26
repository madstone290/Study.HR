import { Layout } from 'antd';
import { Outlet } from 'react-router-dom';


const layoutStyle = {
    padding: "12px 12px", 
    backgroundColor: "#ADD8E6"
}

const contentStyle = {
    padding: 24,
    margin: 0,
    minHeight: 280,
    backgroundColor: "white"
};

export function MainContent() {
    return (
        <Layout style={layoutStyle}>
            <Layout.Content style={contentStyle}>
                <Outlet />
            </Layout.Content>
        </Layout>
    );
}
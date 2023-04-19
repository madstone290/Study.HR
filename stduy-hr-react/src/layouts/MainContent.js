import { Layout } from 'antd';
import { Outlet } from 'react-router-dom';


const layoutStyle = {
    padding: "12px 12px", 
    backgroundColor: "#333333"
}

const contentStyle = {
    padding: 24,
    margin: 0,
    minHeight: 280,
    backgroundColor: "#eeeeee"
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
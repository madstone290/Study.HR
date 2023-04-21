import './App.css';
import { BrowserRouter, Routes, Route, HashRouter } from 'react-router-dom';
import { BaseLayout } from "./BaseLayout";
import { Home } from "./pages/Home";
import { EmployeeListView } from "./pages/Employee/EmployeeListView";
import { NotFound } from './pages/NotFound';
import { DepartmentList } from './pages/Department/DepartmentList';

function App() {
    return (
        <div className="App" style={{ height: "100vh" }}>
            <BrowserRouter>  { /* 정적호스팅인 경우 HashRouter를 이요할 것 */}
                <Routes>
                    <Route path="/" element={<BaseLayout />}>
                        <Route index element={<Home />} />
                        <Route path="employeelist" element={<EmployeeListView />} />
                        <Route path="departments" element={<DepartmentList />} />
                    </Route>
                    <Route path="*" element={<NotFound />} />
                </Routes>
            </BrowserRouter>
        </div>
    );
}

export default App;

import React from 'react';
import logo from './logo.svg';
import './App.css';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import { BaseLayout } from 'Layouts/BaseLayout';
import { Home } from 'Pages/Home';
import { NotFound } from 'Pages/NotFound';
import { EmployeeList } from 'Pages/Employee/EmployeeList';
import { DepartmentList } from 'Pages/Department/DepartmentList';
import { PageRoute } from 'Routes/PageRoute';

function App() {
  return (
    <div className='App' style={{ height: '100vh' }}>
      <BrowserRouter>
        <Routes>
          <Route path='/' element={<BaseLayout />}>
            <Route index element={<Home />} />
            <Route path={PageRoute.EMPLOYEES} element={<EmployeeList />} />
            <Route path={PageRoute.DEPARTMENTS} element={<DepartmentList />} />
          </Route>
          <Route path="*" element={<NotFound />} />
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;

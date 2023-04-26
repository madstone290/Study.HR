import { createContext, useState } from "react";
import { Employee } from "../../data/employee";

export const EmployeeContext = createContext();
export class EmployeeContextValue {
    modalOpen = false;
    setModalOpen = (open) => { };
}
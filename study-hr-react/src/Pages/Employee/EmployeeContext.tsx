import { createContext, useContext } from "react";

export const EmployeeContext = createContext<EmployeeContextValue>({
    modalOpen: false,
    setModalOpen: (_) => { }
});

export const useEmployeeContext = () => useContext(EmployeeContext);

export interface EmployeeContextValue {
    modalOpen: boolean;
    setModalOpen: (open: boolean) => void;
}
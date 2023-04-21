import { Employee } from "../data/employee";
import { api } from "./api-base";

export async function getEmployees() {
    return api.get("employee", 
    { 
        jsonMapper: (json) => json.map(item => Employee.fromJson(item))
    });
}

export async function addEmployee(employee) {
    return api.post("employee", employee, { textMapper: (text) => parseInt(text) });
}

export async function updateEmployee(id, employee) {
    return api.put(`employee/${id}`, employee);
}

export async function deleteEmployee(id) {
    return api.delete(`employee/${id}`);
}



import { Department } from "../data/department";
import { api } from "./api-base";

class DepartmentApi {
    getDepartments() {
        return api.get("department",
            {
                jsonMapper: (json) => json.map(item => Department.fromJson(item))
            });
    }

    addDepartment(department) {
        return api.post("department", department,
            {
                textMapper: (text) => parseInt(text)
            });
    }

    updateDepartment(id, department) {
        return api.put(`department/${id}`, department);
    }

    deleteDepartment(id) {
        return api.delete(`department/${id}`);
    }
}

export const departmentApi = new DepartmentApi();
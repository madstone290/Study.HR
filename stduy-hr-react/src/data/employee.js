import { toKorString } from "../utils/date-util"
import { Dayjs } from "dayjs"

export class Employee {
    key;
    id;
    name;

    /** @type {Dayjs} 데이터형 입사일자 */
    enteredDateAsDate;
    enteredDateAsString;

    dateOfBirthAsDate;
    dateOfBirthAsString;
    
    address;
    email;
    phoneNumber;
    phoneNumberHead;
    phoneNumberBody
    loginId;
    loginPassword;
    desc;

    /** @type {number} */
    rate;

    /** @type {string} */
    salaryType = SalaryType.Monthly;

    mergePhoneNumber() {
        this.phoneNumber = this.phoneNumberHead + "-" + this.phoneNumberBody;
    }

    static new(key, name, age) {
        const emp = new Employee();
        emp.key = key;
        emp.name = name;
        emp.age = age;
        return emp;
    }

    static empty() {
        const emp = new Employee();
        emp.salaryType = null;
        return emp;
    }

    static fromJson(json) {
        const emp = new Employee();
        emp.key = json.id;
        emp.id = json.id;
        emp.name = json.name;
        emp.dateOfBirthAsString = json.dateOfBirth;
        emp.enteredDateAsString = json.enteredDate;
        emp.phoneNumber = json.phoneNumber;
        emp.salaryType = json.salaryType;
        emp.baseSalary = json.baseSalary;
        emp.salaryCurrency = json.salaryCurrency;
        emp.address = json.address;
        emp.email = json.email;
        emp.loginId = json.loginId;
        emp.loginPassword = json.loginPassword;
        emp.desc = json.desc;
        emp.rate = json.rate;

        return emp;
    }
}

export const SalaryType = {
    Monthly: "Monthly",
    Weekly: "Weekly",
    Hourly: "Hourly",
};
Object.freeze(SalaryType);

export const employeeList = [
    Employee.new(1, "John", 30),
    Employee.new(2, "Bruce", 38),
    Employee.new(3, "Alex", 22),
    Employee.new(4, "Susan", 31),
    Employee.new(5, "Lyn", 35),
    Employee.new(6, "Sally", 23),
    Employee.new(7, "Lina", 34),
    Employee.new(8, "Mundo", 20),
    Employee.new(9, "김이박", 20),
    Employee.new(10, "수박", 30),
    Employee.new(11, "John", 30),
    Employee.new(12, "Bruce", 38),
    Employee.new(13, "Alex", 22),
    Employee.new(14, "Susan", 31),
    Employee.new(15, "Lyn", 35),
    Employee.new(16, "Sally", 23),
    Employee.new(17, "Lina", 34),
    Employee.new(18, "Mundo", 20),
    Employee.new(19, "김이박", 20),
    Employee.new(20, "김박", 30),
    Employee.new(21, "John", 30),
    Employee.new(22, "Bruce", 38),
    Employee.new(23, "Alex", 22),
    Employee.new(24, "Susan", 31),
    Employee.new(25, "Lyn", 35),
    Employee.new(26, "Sally", 23),
    Employee.new(27, "Lina", 34),
    Employee.new(28, "Mundo", 20),
    Employee.new(29, "김이박", 20),
];
Object.freeze(employeeList);
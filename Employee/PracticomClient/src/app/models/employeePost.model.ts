import { EmployeePositionPost } from "./employeePositionPost.model"

enum Gender {
    male = 1,
    female = 2
}
export class EmployeePost {
    firstName!: string
    lastName !: string
    tz!: string
    employmentStartDate!: Date
    dateOfBirth!: Date
    gender!: Gender
    status !: boolean
    positions!: EmployeePositionPost[]

}
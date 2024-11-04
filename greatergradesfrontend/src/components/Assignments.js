import { useMemo } from "react";
import { useGetUsersClasses } from "../greatergradesapi/Classes";
import { useContext } from "react";
import { UserContext } from "../functions/UserContext";


const Assignments = ({ courseIds }) => {
    
    const { currentUser } = useContext(UserContext);
    const courses = useGetUsersClasses(courseIds)

    const assignments = useMemo(() => {
        return courses.flatMap(course => course.assignments || []);
    }, [courses])

    const grades = useMemo(() => {
        return assignments.flatMap(assignment => assignment.grades.userId === currentUser?.userId ? [assignment.grades] : [])
    }, [assignments, currentUser])

    return (
        <div>
            {assignments.map((assignment, index) => (
                <div key={index} className="student-dashboard-tile">
                    <p>{assignment.name}</p>
                </div>
            ))}
        </div>
    )
}
export default Assignments;
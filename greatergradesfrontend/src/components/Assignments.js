import { useMemo } from "react";
import { useGetUsersClasses } from "../greatergradesapi/Classes";

const Assignments = ({ courseIds }) => {
    
    const courses = useGetUsersClasses(courseIds)

    const assignments = useMemo(() => {
        return courses.flatMap(course => course.assignments || []);
    }, [courses])

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
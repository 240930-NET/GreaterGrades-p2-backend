import { useState, useEffect, useMemo } from "react";

const Assignments = ({ courseIds }) => {


    const [courses, setCourses] = useState([]);
    
    useEffect(() => {
        const fetchCourses = async () => {
            try {
                const responses = await Promise.all(
                    courseIds.map(courseId => 
                        fetch('http://localhost:5000/api/Classes/' + courseId, {
                            headers: {
                                'Authorization': `Bearer ${localStorage.getItem('authToken')}`,
                                'Content-Type': 'application/json'
                            }
                        }).then(res => res.json())
                    )
                )
                setCourses(responses);
            } catch {}
        }
        if (courseIds.length > 0) fetchCourses();

    }, [courseIds])

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
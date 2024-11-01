import { useEffect, useState } from "react";



const Tiles = () => {
    const [courses, setCourses] = useState([]);
    const url = 'http://localhost:5000/api/Classes'

    useEffect(() => {
        const fetchCourses = async () => {
            const response = await fetch(url, {
                headers: {
                    'Authorization': `Bearer ${localStorage.getItem('authToken')}`,
                    'Content-Type': 'application/json'
                }
            });
            const data = await response.json();
            setCourses(data);
        };
        fetchCourses();
    }, []);

    return (
        <div>
            {courses.map((course) => <div className="student-dashboard-tile" key={course.classId}>{course.subject}</div>)}
        </div>
    );
};

export default Tiles;
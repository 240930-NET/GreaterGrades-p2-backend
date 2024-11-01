import { useEffect, useState } from "react";

const Tiles = ({ courseIds }) => {

    const [courses, setCourses] = useState([])

    useEffect(() => {
        const fetchCourses = async () => {
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
        }
        if (courseIds && courseIds.length > 0) fetchCourses();

    }, [courseIds])

    return (
        <div>
            {courses.map((course, index) => (
                <div key={index} className="student-dashboard-tile">
                    <p>{course.subject}</p>
                </div>
            ))}
        </div>
    )

}


















// const Tiles = () => {
//     const [courses, setCourses] = useState([]);
//     const url = 'http://localhost:5000/api/Classes/'


//     useEffect(() => {
//         const fetchCourses = async () => {
//             const response = await fetch(url, {
//                 headers: {
//                     'Authorization': `Bearer ${localStorage.getItem('authToken')}`,
//                     'Content-Type': 'application/json'
//                 }
//             });
//             const data = await response.json();
//             setCourses(data);
//         };
//         fetchCourses();
//     }, []);

//     return (
//         <div>
//             {courses.map((course) => <div className="student-dashboard-tile" key={course.classId}>{course.subject}</div>)}
//         </div>
//     );
// };

export default Tiles;
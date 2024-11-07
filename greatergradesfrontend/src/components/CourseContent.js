import { useContext } from "react";
import { UserContext } from '../functions/UserContext';
import { getStorageItem } from "../functions/LocalStorage";

const CourseContent = () => {
    const {currentUser} = useContext(UserContext);

    // if user is student display this
    if (currentUser?.role === 0){
        return (
            <div className="student-content">
                <div className="student-tiles">
                    <p>{getStorageItem('currentCourse').subject}</p>
                </div>
            </div>
        )
    }

    // if user is teacher or admin display this
    else{
        return (
            <div className="course-content">
                <h3 className="course-title">{getStorageItem('currentCourse').subject}</h3>
                <div className="course-body">
                    <div className="course-list-title">
                        <p>Students: {getStorageItem('currentCourse').students?.length || 0}</p>
                        <div className="course-list-line"/>
                        <div className="course-list-entries">
                            {getStorageItem('currentCourse').students.map((student, index) => (
                                <p>{student.firstName} {student.lastName}</p>
                            ))}
                        </div>
                    </div>
                    <div className="course-list-title">
                        <p>Teachers: {getStorageItem('currentCourse').teachers?.length || 0}</p>
                        <div className="course-list-line"/>
                        <div className="course-list-entries">
                            {getStorageItem('currentCourse').teachers.map((teacher, index) => (
                                <p>{teacher.firstName} {teacher.lastName}</p>
                            ))}
                        </div>
                    </div>
                    <div className="course-list-title">
                        <p>Assignments: {getStorageItem('currentCourse').assignments?.length || 0}</p>
                        <div className="course-list-line"/>
                    </div>
                </div>
            </div>
        ) 
    }
}

export default CourseContent;
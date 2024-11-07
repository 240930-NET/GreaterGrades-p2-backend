import { useContext } from "react";
import { UserContext } from '../functions/UserContext';
import { getStorageItem } from "../functions/LocalStorage";
import UserTile from './UserTile';
import { RoleEnum } from "../enum/Role";

const CourseContent = () => {
    const { currentUser } = useContext(UserContext);
    const currentCourse = getStorageItem('currentCourse');

    // if user is student display this
    if (currentUser?.role === 0) {
        return (
            <div className="course-content">
                <h3 className="course-title">{currentCourse.subject}</h3>
                <div className="course-body">
                    <div className="course-list-title">
                        <p>Students: {currentCourse.students?.length || 0}</p>
                        <div className="course-list-line" />
                        <div className="course-list-entries">
                            {currentCourse.students.map((student, index) => (
                                <UserTile 
                                    key={index} 
                                    firstName={student.firstName} 
                                    lastName={student.lastName} 
                                    role={RoleEnum[student?.role]} 
                                />
                            ))}
                        </div>
                    </div>
                    <div className="course-list-title">
                        <p>Teachers: {currentCourse.teachers?.length || 0}</p>
                        <div className="course-list-line" />
                        <div className="course-list-entries">
                            {currentCourse.teachers.map((teacher, index) => (
                                <UserTile 
                                    key={index} 
                                    firstName={teacher.firstName} 
                                    lastName={teacher.lastName} 
                                    role={RoleEnum[teacher?.role]} 
                                />
                            ))}
                        </div>
                    </div>
                    <div className="course-list-title">
                        <p>Assignments: {currentCourse.assignments?.length || 0}</p>
                        <div className="course-list-line" />
                    </div>
                </div>
            </div>
        );
    }

    // if user is teacher or admin display this
    else {
        return (
            <div className="course-content">
                <h3 className="course-title">{currentCourse.subject}</h3>
                <div className="course-body">
                    <div className="course-list-title">
                        <p>Students: {currentCourse.students?.length || 0}</p>
                        <div className="course-list-line" />
                        <div className="course-list-entries">
                            {currentCourse.students.map((student, index) => (
                                <UserTile 
                                    key={index} 
                                    firstName={student.firstName} 
                                    lastName={student.lastName} 
                                    role={RoleEnum[student?.role]}
                                />
                            ))}
                        </div>
                    </div>
                    <div className="course-list-title">
                        <p>Teachers: {currentCourse.teachers?.length || 0}</p>
                        <div className="course-list-line" />
                        <div className="course-list-entries">
                            {currentCourse.teachers.map((teacher, index) => (
                                <UserTile 
                                    key={index} 
                                    firstName={teacher.firstName} 
                                    lastName={teacher.lastName} 
                                    role={RoleEnum[teacher?.role]}
                                />
                            ))}
                        </div>
                    </div>
                    <div className="course-list-title">
                        <p>Assignments: {currentCourse.assignments?.length || 0}</p>
                        <div className="course-list-line" />
                    </div>
                </div>
            </div>
        );
    }
}

export default CourseContent;

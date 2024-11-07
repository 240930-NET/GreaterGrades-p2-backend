import { useContext } from "react";
import { UserContext } from '../functions/UserContext';
import { getStorageItem } from "../functions/LocalStorage";
import forestImage from "../images/forest.jfif";

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

    // if user is teacher display this
    else if (currentUser?.role === 1){
        return (
            <div className="course-content">
                <h3 className="course-title">{getStorageItem('currentCourse').subject}</h3>
                <img src={forestImage} alt="Course placeholder" className="course-image"/>
                <div className="course-footer">
                    <p>{getStorageItem('currentCourse').students?.length || 0} Students</p>
                    <p>{getStorageItem('currentCourse').teachers?.length || 0} Teachers</p>
                </div>
            </div>
        ) 
    }
}

export default CourseContent;
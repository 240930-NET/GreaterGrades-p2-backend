import { useGetUsersClasses } from "../greatergradesapi/Classes";
import forestImage from "../images/forest.jfif";
import { setStorageItem } from '../functions/LocalStorage';

const Tiles = ({ courseIds, setSelectedItem }) => { 
    const classes = useGetUsersClasses(courseIds);
    console.log(classes);

    const clickOnCourse = (course) => {
        setStorageItem('currentCourse', course);
        console.log("setSelectedItem:", setSelectedItem);
        setSelectedItem('course info');
    };

    return (
        <div className="tiles-container">
            {classes.map((course, index) => (
                <button key={index} onClick={() => clickOnCourse(course)} className="dashboard-tile-link">
                    <div className="dashboard-tile">
                        <h3 className="tile-title">{course.subject}</h3>
                        <img src={forestImage} alt="Course placeholder" className="tile-image" />
                        <div className="tile-footer">
                            <p>{course.students?.length || 0} Students</p>
                            <p>{course.teachers?.length || 0} Teachers</p>
                        </div>
                    </div>
                </button>
            ))}
        </div>
    );
};

export default Tiles;

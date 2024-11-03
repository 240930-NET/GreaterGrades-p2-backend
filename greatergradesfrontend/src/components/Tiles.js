import { Link } from "react-router-dom";
import { useGetUsersClasses } from "../greatergradesapi/Classes";

const Tiles = ({ courseIds }) => {

    const classes = useGetUsersClasses(courseIds);

    return (
        <div>
            {classes.map((course, index) => (
                <Link key={index} to="/Course">
                    <div className="student-dashboard-tile">
                        <p>{course.subject}</p>
                    </div>
                </Link>
            ))}
        </div>
    )

}

export default Tiles;
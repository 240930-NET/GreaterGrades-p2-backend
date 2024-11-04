import Assignments from "../components/Assignments";
import { useContext } from "react";
import { UserContext } from "../functions/UserContext";

const Course = () => {
    const { currentUser } = useContext(UserContext);
    
    return (
        <main>
            <Assignments courseIds={currentUser?.classIds} />
        </main>
    )
}
export default Course;
import Assignments from "../components/Assignments";

const { currentUser } = useContext(UserContext);
const Course = () => {
    return (
        <main>
            <Assignments courseIds={currentUser?.classIds} />
        </main>
    )
}
export default Course;
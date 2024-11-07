import { useState, useContext } from "react";
import { UserContext } from "../functions/UserContext";
import { useGetAllClasses } from "../greatergradesapi/Classes";
import Tiles from "./Tiles";
import AddClassPopup from "./AddClassPopup";

const ClassesContent = ({setSelectedItem}) => {
    const allClasses = useGetAllClasses();
    const classIds = allClasses.flatMap(course => course.classId);
    const { currentUser } = useContext(UserContext);
    const [isPopupOpen, setPopupOpen] = useState(false);

    const handleAddClassClick = () => {
        setPopupOpen(true);
    };

    return (
        <div className="dashboard-content">
            <div className="dashboard-header">
                <h3>Classes</h3>
                <button className="add-class-button" onClick={handleAddClassClick}>
                    Add New Class
                </button>
            </div>
            <div className="dashboard-tiles">
                <Tiles courseIds={classIds} setSelectedItem={setSelectedItem}/>
            </div>
            {isPopupOpen && (
                <AddClassPopup onClose={() => setPopupOpen(false)} institutionId={currentUser?.institutionId} />
            )}
        </div>
    )
}

export default ClassesContent;
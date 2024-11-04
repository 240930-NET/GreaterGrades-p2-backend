import { useContext } from "react";
import { UserContext } from '../functions/UserContext';
import Tiles from "./Tiles";

const TaughtClasses = () => {
    const { currentUser } = useContext(UserContext);


    return (
        <div className="dashboard-content">
            <div>
                <h3>Taught Classes</h3>
                <div className="dashboard-tiles">
                    <Tiles courseIds={currentUser?.taughtClassIds} />
                </div>
            </div>
        </div>
    )
}

export default TaughtClasses;
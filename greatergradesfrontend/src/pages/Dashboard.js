import { useEffect, useMemo, useState, useContext } from "react";
import Header from "../components/Header";
import SideBar from "../components/SideBar";
import DashboardContent from "../components/DashboardContent";
import ProfileContent from "../components/ProfileContent";
import EnrolledClasses from "../components/EnrolledClasses";
import TaughtClasses from "../components/TaughtClasses";
import { UserContext } from '../functions/UserContext';
import { useGetUsersClasses } from "../greatergradesapi/Classes";

const Dashboard = () => {

    const { currentUser } = useContext(UserContext);
    const [selectedItem, setSelectedItem] = useState('dashboard');
    const [sidebarItems, setSidebarItems] = useState([]);
    const courses = useGetUsersClasses(currentUser?.classIds)
    const courseNames = useMemo(() => {
        return courses.flatMap(course => course.subject || '');
    }, [courses])

    useEffect(() => {
        const newSidebarItems = [];

        // User is Student
        if (currentUser?.role === 0) {
            if (currentUser?.taughtclassIds > 0) {
                newSidebarItems.push(
                    { id: 'dashboard', label: 'Dashboard'},
                    { id: 'profile', label: 'Profile'},
                    { id: 'enrolled classes', label: 'Enrolled Classes', assignmentLabels: courseNames},
                    { id: 'taught classes', label: 'Taught Classes'}
                )
            } else {
                newSidebarItems.push(
                    { id: 'dashboard', label: 'Dashboard'},
                    { id: 'profile', label: 'Profile'},
                    { id: 'enrolled classes', label: 'Enrolled Classes', assignmentLabels: courseNames}
                )
            }
        }

        // User is Teacher
        else if (currentUser?.role === 1) {
            newSidebarItems.push(
                { id: 'dashboard', label: 'Dashboard'},
                { id: 'profile', label: 'Profile'},
                { id: 'enrolled classes', label: 'Enrolled Classes'},
                { id: 'taught classes', label: 'Taught Classes'}
            )
        }

        // User is Institutional Admin
        else if (currentUser?.role === 2) {
            newSidebarItems.push(
                { id: 'dashboard', label: 'Dashboard'},
                { id: 'profile', label: 'Profile'},
                { id: 'enrolled classes', label: 'Enrolled Classes'},
                { id: 'taught classes', label: 'Taught Classes'}
            )
        }

        // User is Admin
        else if (currentUser?.role === 3) {
            newSidebarItems.push(
                { id: 'dashboard', label: 'Dashboard'},
                { id: 'profile', label: 'Profile'},
                { id: 'enrolled classes', label: 'Enrolled Classes', assignmentLabels: courseNames},
                { id: 'taught classes', label: 'Taught Classes'}
            )
        }

        setSidebarItems(newSidebarItems);
    }, [currentUser, courseNames])


    // Switch statement to display which component should take up the main screen.
    const renderContent = () => {
        switch (selectedItem) {
            case 'dashboard':
                return <DashboardContent />;
            case 'profile':
                return <ProfileContent />;
            case 'enrolled classes':
                return <EnrolledClasses />;
            case 'taught classes':
                return <TaughtClasses />;
            default:
                return <div>doesnt match....</div>
        }
    }

    return (
        <main className='student-dashboard'>
            <SideBar items={sidebarItems} selectedItem={selectedItem} onSelectItem={setSelectedItem} />
            <div className='student-body'>
                <Header />
                {renderContent()}
            </div>
        </main>
    );
};

export default Dashboard;
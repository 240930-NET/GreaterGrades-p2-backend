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
    const courses = useGetUsersClasses(currentUser?.classIds);
    const courseNames = useMemo(() => {
        return courses.flatMap(course => course.subject || '');
    }, [courses]);

    useEffect(() => {
        const newSidebarItems = [];

        newSidebarItems.push(
            { id: 'dashboard', label: 'Dashboard' },
            { id: 'profile', label: 'Profile' },
            {
                id: 'enrolled classes',
                label: 'Enrolled Classes',
                courses: courses.map(course => ({
                    id: course.id,
                    label: course.subject,
                    assignments: course.assignments || []
                }))
            },
            { id: 'taught classes', label: 'Taught Classes' }
        );

        setSidebarItems(newSidebarItems);
    }, [currentUser, courses]);

    const renderContent = () => {
        switch (selectedItem) {
            case 'dashboard':
                return <DashboardContent />;
            case 'profile':
                return <ProfileContent />;
            case 'enrolled classes':
                return <EnrolledClasses courses={courses} />;
            case 'taught classes':
                return <TaughtClasses />;
            default:
                return <div>doesnt match....</div>;
        }
    };

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

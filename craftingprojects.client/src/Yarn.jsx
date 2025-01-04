import { useEffect, useState } from "react";

const Yarn = () => {
    const [yarns, setYarns] = useState([]);

    useEffect(() => {
        populateYarnData();
    }, []);

    useEffect(() => {
        console.log("Updated yarns:", yarns); // Logs state updates
    }, [yarns]);

    async function populateYarnData() {
        try {
            console.log("Fetching data from API...");

            const response = await fetch('http://localhost:5121/api/yarn'); // Ensure this matches your API

            console.log("Response status:", response.status);

            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }

            const data = await response.json();
            console.log("Fetched data:", data);

            setYarns(data);
        } catch (error) {
            console.error("Error fetching yarn data:", error);
        }
    }


    const yarnContents = yarns.length > 0 ? (
        <div>
            {yarns.map(yarn => (
                <ul key={yarn.yarnId}>
                    <li className='yarnID'>{yarn.yarnId}</li>
                    <li>{yarn.name}</li>
                </ul>
            ))}
        </div>
    ) : (
        <p>Loading or no data available...</p>
    );

    return (
        <div className="container">
            {yarnContents}
            <div> bui</div>
        </div>
    );
}

export default Yarn;

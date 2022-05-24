import axios from 'https://cdn.skypack.dev/axios';


async function loadIntoTable() {
    var url = "https://app.sportdataapi.com/api/v1/soccer/topscorers?apikey=3983ad80-d775-11ec-b10a-b1449bbed000&season_id=2100";
    try {
        await axios.get(url).then((response) => {
            const clubs = response.data.data;
            if (clubs.length === 0)
                alert("0");
            console.log(clubs);
        });
    } catch (error) {
        console.log('Error', error);
    }
}
document.addEventListener("DOMContentLoaded", loadIntoTable);


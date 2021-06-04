// Global variables 
let map; 
let markers = [];
let infoWindow;
let currentSelected;

// Initialize the map at users location
function initMap(position) {

    let lat = position.coords.latitude;
    let lng = position.coords.longitude;

    // centre coordinates for the map
    const myMapCenter = {
        lat: lat,
        lng: lng
    }

    infoWindow = new google.maps.InfoWindow();

    // create map and target HTML element to put map in
    map = new google.maps.Map(document.getElementById('map'), {
        center: myMapCenter,
        zoom: 14
    });

    // create marker and set its position
    const marker = new google.maps.Marker({
        map: map,
        position: myMapCenter,
        title: 'my location'
    });

    // info window for current location
    google.maps.event.addListener(marker, 'click', function () {
        infoWindow.setContent(
            '<h5>Your current location</h5>'
        );
        infoWindow.open(map, marker);
    });
}

// Function to get user location 
function getLocation(){
    {
        if (navigator.geolocation)

        {
            var options = {
                enableHighAccuracy: true,
                timeout: 5000,
                maximumAge: 0
            };
            navigator.geolocation.getCurrentPosition( initMap, error, options);
        }
        else
        { x.innerHTML= "Geolocation is not supported by this browser."; }
    }
}

// Function to clear markers from the map
function clearLocations() {
    infoWindow.close();
    for(let i = 0; i < markers.length; i++){
        markers[i].setMap(null);
    }
    markers.length = 0;
}

// Re-initialize the map with markers at all Minsk Locations
function getWalmartLocations() {

    clearLocations();

    const walmartStores = [
        {
            position: new google.maps.LatLng(53.9190806, 27.5768074),
            type: 'store',
            title: 'Grocery Pals - Komarovka dist.',
            address: '8 Horuzhai St, Minsk, Belarus'
        },
        {
            position: new google.maps.LatLng(53.933529, 27.64947),
            type: 'store',
            title: 'Grocery Pals - Dana Moll dist.',
            address: '11 Petra Mstislavca St, Minsk, Belarus'
        },
        {
            position: new google.maps.LatLng(53.9079983, 27.5350847),
            type: 'store',
            title: 'Grocery Pals - Gallileo dist.',
            address: '6 Bobruiskaya St, Minsk, Belarus'
        },
        {
            position: new google.maps.LatLng(53.9054286, 27.5727813),
            type: 'store',
            title: 'Grocery Pals - Galleria dist.',
            address: '6 Pobeditelei Ave, Minsk, Belarus'
        },
        {
            position: new google.maps.LatLng(53.9374601, 27.513473),
            type: 'store',
            title: 'Grocery Pals - Arena City dist.',
            address: '84 Podeditelei Ave, Minsk, Belarus'
        },
        {
            position: new google.maps.LatLng(53.8552739, 27.5852852),
            type: 'store',
            title: 'Grocery Pals - E-City dist.',
            address: '3 Gashkevicha St, Minsk, Belarus'
        },
        {
            position: new google.maps.LatLng(53.9160307, 27.5279503),
            type: 'store',
            title: 'Grocery Pals - Bonus Mall dist.',
            address: '2-2 V.Golubka St, Minsk, Belarus'
        },
        {
            position: new google.maps.LatLng(53.8843648, 27.4988264),
            type: 'store',
            title: 'Grocery Pals - Magnit dist.',
            address: '106 Dzerzhinskogo Ave, Minsk, Belarus'
        }
    ]

    // creates a marker for each location
    for (let i = 0; i < walmartStores.length; i++){
        let html = "<b>" + walmartStores[i].title + "</b> <br/>" + walmartStores[i].address;

        let marker = new google.maps.Marker({
            position: walmartStores[i].position,
            map: map
        });

        markers.push(marker);

        google.maps.event.addListener(marker, 'click', function() {
            currentSelected = walmartStores[i].address;

            map.panTo(this.getPosition());

            infoWindow.setContent(html + '<br/>' +
                '<button type="button" class="btn btn-primary location-button" onclick="setStoreLocation()">Set Location</button>');
            infoWindow.open(map, marker);
          });
    }

    map.setZoom(11);
}

// Re-initialize the map with markers at all Brest locations
function getLoblawsLocations(){

    clearLocations();
    
    const loblawsStores = [
        {
            position: new google.maps.LatLng(52.0990742, 23.6925411),
            type: 'store',
            title: 'Grocery Pals - Brest Rinok dist.',
            address: '25 Karbysheva St, Brest, Belarus'
        },
        {
            position: new google.maps.LatLng(52.0953473, 23.6954599),
            type: 'store',
            title: 'Grocery Pals - Laguna dist.',
            address: '19 Volgogradskaya St, Brest, Belarus'
        },
        {
            position: new google.maps.LatLng(52.1021704, 23.7684761),
            type: 'store',
            title: 'Grocery Pals - Yubileyny dist.',
            address: '328 Moscow St, Brest, Belarus'
        }
    ];

    for (let i = 0; i <= loblawsStores.length; i++){
        let html = "<b>" + loblawsStores[i].title + "</b> <br/>" + loblawsStores[i].address;

        let marker = new google.maps.Marker({
            position: loblawsStores[i].position,
            map: map
        });

        markers.push(marker);

        google.maps.event.addListener(marker, 'click', function() {
            currentSelected = loblawsStores[i].address;

            map.panTo(this.getPosition());

            infoWindow.setContent(html + '<br/>' +
                '<button type="button" class="btn btn-primary location-button" onclick="setStoreLocation()">Set Location</button>');
            infoWindow.open(map, marker);
          });
    };

    map.setZoom(11);
}

// Re-initialize the map with markers at all Gomel locations
function getMetroLocations() {

    clearLocations();

    const metroStores = [
        {
            position: new google.maps.LatLng(52.4239855, 30.9951667),
            type: 'store',
            title: 'Grocery Pals - Secret dist.',
            address: '65 Gagarina St, Gomel, Belarus'
        },
        {
            position: new google.maps.LatLng(52.4057513, 30.9218757),
            type: 'store',
            title: 'Grocery Pals - Zarko dist.',
            address: '62a Rechizky Ave, Gomel, Belarus'
        },
        {
            position: new google.maps.LatLng(52.3883508, 31.0269088),
            type: 'store',
            title: 'Grocery Pals - Etyud dist.',
            address: '57 Ilycha St, Gomel, Belarus'
        }
    ];

    for (let i = 0; i <= metroStores.length; i++){
        let html = "<b>" + metroStores[i].title + "</b> <br/>" + metroStores[i].address;

        let marker = new google.maps.Marker({
            position: metroStores[i].position,
            map: map
        });

        markers.push(marker);

        google.maps.event.addListener(marker, 'click', function() {
            currentSelected = metroStores[i].address;

            map.panTo(this.getPosition());

            infoWindow.setContent(html + '<br/>' +
                '<button type="button" class="btn btn-primary location-button" onclick="setStoreLocation()">Set Location</button>');
            infoWindow.open(map, marker);
          });
    };

    map.setZoom(11);
}

// Re-initialize the map with markers at all Vitebsk locations
function getCostcoLocations() {

    clearLocations();

    const costcoStores = [
        {
            position: new google.maps.LatLng(55.1957225, 30.1853476, 17),
            type: 'store',
            title: 'Grocery Pals - Metro Park dist.',
            address: '10A Kosmonavtov St, Vitebsk, Belarus'
        },
        {
            position: new google.maps.LatLng(55.1704452, 30.2180282),
            type: 'store',
            title: 'Grocery Pals - TriO dist.',
            address: '15V Stroitelei St, Vitebsk, Belarus'
        },
        {
            position: new google.maps.LatLng(55.1761303, 30.2029482),
            type: 'store',
            title: 'Grocery Pals - Belarus dist.',
            address: '3 Generala Beloborodova St, Vitebsk, Belarus'
        }
    ];

    for (let i = 0; i <= costcoStores.length; i++){
        let html = "<b>" + costcoStores[i].title + "</b> <br/>" + costcoStores[i].address;

        let marker = new google.maps.Marker({
            position: costcoStores[i].position,
            map: map
        });

        markers.push(marker);

        google.maps.event.addListener(marker, 'click', function() {
            currentSelected = costcoStores[i].address;

            map.panTo(this.getPosition());

            infoWindow.setContent(html + '<br/>' +
                '<button type="button" class="btn btn-primary location-button" onclick="setStoreLocation()">Set Location</button>');
            infoWindow.open(map, marker);
          });
    };

    map.setZoom(11);
}

// Set store location 
function setStoreLocation(){

    let store = document.getElementById('defaultStoreLocation');

    store.innerHTML = currentSelected;
}

// Exception handling
function error(e) {
    console.log("error code:" + e.code + 'message: ' + e.message );
}
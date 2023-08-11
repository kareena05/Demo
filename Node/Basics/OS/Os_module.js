const os = require('os');
console.log(os.arch()); //64 or 32 bit
console.log(os.userInfo());
console.log(os.homedir());
console.log(os.freemem()/(1024*1024*1024));
console.log(os.hostname());
console.log(os.platform());

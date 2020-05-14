// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using multiple_inheritance.Models;

namespace multiple_inheritance
{
    /// <summary> The Service service client. </summary>
    public partial class ServiceClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal ServiceRestClient RestClient { get; }
        /// <summary> Initializes a new instance of ServiceClient for mocking. </summary>
        protected ServiceClient()
        {
        }
        /// <summary> Initializes a new instance of ServiceClient. </summary>
        internal ServiceClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            RestClient = new ServiceRestClient(clientDiagnostics, pipeline, endpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Get a horse with name &apos;Fred&apos; and isAShowHorse true. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Horse>> GetHorseAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ServiceClient.GetHorse");
            scope.Start();
            try
            {
                return await RestClient.GetHorseAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a horse with name &apos;Fred&apos; and isAShowHorse true. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Horse> GetHorse(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ServiceClient.GetHorse");
            scope.Start();
            try
            {
                return RestClient.GetHorse(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put a horse with name &apos;General&apos; and isAShowHorse false. </summary>
        /// <param name="horse"> Put a horse with name &apos;General&apos; and isAShowHorse false. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<string>> PutHorseAsync(Horse horse, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ServiceClient.PutHorse");
            scope.Start();
            try
            {
                return await RestClient.PutHorseAsync(horse, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put a horse with name &apos;General&apos; and isAShowHorse false. </summary>
        /// <param name="horse"> Put a horse with name &apos;General&apos; and isAShowHorse false. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<string> PutHorse(Horse horse, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ServiceClient.PutHorse");
            scope.Start();
            try
            {
                return RestClient.PutHorse(horse, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a pet with name &apos;Peanut&apos;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Pet>> GetPetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ServiceClient.GetPet");
            scope.Start();
            try
            {
                return await RestClient.GetPetAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a pet with name &apos;Peanut&apos;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Pet> GetPet(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ServiceClient.GetPet");
            scope.Start();
            try
            {
                return RestClient.GetPet(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put a pet with name &apos;Butter&apos;. </summary>
        /// <param name="pet"> Put a pet with name &apos;Butter&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<string>> PutPetAsync(Pet pet, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ServiceClient.PutPet");
            scope.Start();
            try
            {
                return await RestClient.PutPetAsync(pet, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put a pet with name &apos;Butter&apos;. </summary>
        /// <param name="pet"> Put a pet with name &apos;Butter&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<string> PutPet(Pet pet, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ServiceClient.PutPet");
            scope.Start();
            try
            {
                return RestClient.PutPet(pet, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a feline where meows and hisses are true. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Feline>> GetFelineAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ServiceClient.GetFeline");
            scope.Start();
            try
            {
                return await RestClient.GetFelineAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a feline where meows and hisses are true. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Feline> GetFeline(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ServiceClient.GetFeline");
            scope.Start();
            try
            {
                return RestClient.GetFeline(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put a feline who hisses and doesn&apos;t meow. </summary>
        /// <param name="feline"> Put a feline who hisses and doesn&apos;t meow. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<string>> PutFelineAsync(Feline feline, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ServiceClient.PutFeline");
            scope.Start();
            try
            {
                return await RestClient.PutFelineAsync(feline, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put a feline who hisses and doesn&apos;t meow. </summary>
        /// <param name="feline"> Put a feline who hisses and doesn&apos;t meow. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<string> PutFeline(Feline feline, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ServiceClient.PutFeline");
            scope.Start();
            try
            {
                return RestClient.PutFeline(feline, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a cat with name &apos;Whiskers&apos; where likesMilk, meows, and hisses is true. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Cat>> GetCatAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ServiceClient.GetCat");
            scope.Start();
            try
            {
                return await RestClient.GetCatAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a cat with name &apos;Whiskers&apos; where likesMilk, meows, and hisses is true. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Cat> GetCat(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ServiceClient.GetCat");
            scope.Start();
            try
            {
                return RestClient.GetCat(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put a cat with name &apos;Boots&apos; where likesMilk and hisses is false, meows is true. </summary>
        /// <param name="cat"> Put a cat with name &apos;Boots&apos; where likesMilk and hisses is false, meows is true. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<string>> PutCatAsync(Cat cat, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ServiceClient.PutCat");
            scope.Start();
            try
            {
                return await RestClient.PutCatAsync(cat, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put a cat with name &apos;Boots&apos; where likesMilk and hisses is false, meows is true. </summary>
        /// <param name="cat"> Put a cat with name &apos;Boots&apos; where likesMilk and hisses is false, meows is true. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<string> PutCat(Cat cat, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ServiceClient.PutCat");
            scope.Start();
            try
            {
                return RestClient.PutCat(cat, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a kitten with name &apos;Gatito&apos; where likesMilk and meows is true, and hisses and eatsMiceYet is false. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Kitten>> GetKittenAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ServiceClient.GetKitten");
            scope.Start();
            try
            {
                return await RestClient.GetKittenAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a kitten with name &apos;Gatito&apos; where likesMilk and meows is true, and hisses and eatsMiceYet is false. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Kitten> GetKitten(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ServiceClient.GetKitten");
            scope.Start();
            try
            {
                return RestClient.GetKitten(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put a kitten with name &apos;Kitty&apos; where likesMilk and hisses is false, meows and eatsMiceYet is true. </summary>
        /// <param name="kitten"> Put a kitten with name &apos;Kitty&apos; where likesMilk and hisses is false, meows and eatsMiceYet is true. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<string>> PutKittenAsync(Kitten kitten, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ServiceClient.PutKitten");
            scope.Start();
            try
            {
                return await RestClient.PutKittenAsync(kitten, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put a kitten with name &apos;Kitty&apos; where likesMilk and hisses is false, meows and eatsMiceYet is true. </summary>
        /// <param name="kitten"> Put a kitten with name &apos;Kitty&apos; where likesMilk and hisses is false, meows and eatsMiceYet is true. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<string> PutKitten(Kitten kitten, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ServiceClient.PutKitten");
            scope.Start();
            try
            {
                return RestClient.PutKitten(kitten, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
